namespace MonthlyPremiums.Domain
{
  public static class CommonConstants
  {
    #region Occupation Types
    public const string CLEANER = "Cleaner";
    public const string DOCTOR = "Doctor";
    public const string AUTHOR = "Author";
    public const string FARMER = "Farmer";
    public const string MECHANIC = "Mechanic";
    public const string Florist = "Florist";
    #endregion

    #region Ratings Types
    public const string PROFESSIONAL = "Professional";
    public const string WHITE_COLLAR = "WhiteCollar";
    public const string LIGHT_MANUAL = "LightManual";
    public const string HEAVY_MANUAL = "HeavyManual";
    #endregion Ratings

    #region Exception Messages
    public const string INVALID_CALCULATOR_PARAMETER_INPUT = "No valid inputs provided for premium calculation.";
    public const string INVALID_DEATH_SUM_INSURED_INPUT = "Valid death sum insured amount not provided, please try again.";
    public const string INVALID_AGE_INPUT = "Valid age not provided, please try again";
    public const string OUT_OF_RANGE_AGE_INPUT = "Age must be between 1yr to 120yr, please try again";
    public const string PREMIUM_NULL = "Unable to calculate premium, please try again later.";
    public const string NO_OCCUPATIONS_FOUND_EXCEPTION = "No Occupation found in the Repository.";
    public const string OCCUPATION_NOT_FOUND = "Unable to find occupation, please try again later.";
    #endregion

  }
}
