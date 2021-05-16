using MonthlyPremiums.Domain;
using MonthlyPremiums.Domain.Entities;
using MonthlyPremiums.Repository;
using MonthlyPremiums.Service.Contracts;
using MonthlyPremiums.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonthlyPremiums.Service.Concretes
{
  /// <summary>
  /// Service class that fetches Occupations from the Repository
  /// </summary>
  public class OccupationService : IOccupationService
  {
    private List<Occupation> _occupations;
    private IOccupationRepository _occupationRepository;

    public OccupationService(IOccupationRepository occupationRepository)
    {
      _occupationRepository = occupationRepository;
    }

    public List<Occupation> GetAllOccupations()
    {
      _occupations = _occupationRepository.GetAllOccupations();
      #region Business validation
      if (_occupations == null)
      {
        throw new NotFoundException(CommonConstants.NO_OCCUPATIONS_FOUND_EXCEPTION);
      }
      #endregion


      return _occupations;
    }
    public Occupation GetOccupationById(int id)
    {
      Occupation occupation = null;

      #region Business validation
      if (id <= 0)
      {
        throw new NotFoundException(CommonConstants.NO_OCCUPATIONS_FOUND_EXCEPTION);
      }
      #endregion

      occupation = GetAllOccupations().Where(ocup => ocup.Id == id).FirstOrDefault();
      return occupation;
    }
  }
}