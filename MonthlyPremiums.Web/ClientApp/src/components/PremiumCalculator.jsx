import React, { useState } from "react";
import { TextField, Button, Grid, FormControl, InputLabel, Select, MenuItem, FormHelperText } from "@material-ui/core";
import { makeStyles } from '@material-ui/core/styles';
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider, KeyboardDatePicker } from "@material-ui/pickers";
import moment from 'moment';

const useStyles = makeStyles((theme) => ({
  container: {
    display: 'flex',
    flexWrap: 'wrap',
  },
  fields: {
    margin: 20,
    marginLeft: theme.spacing(1),
    marginRight: theme.spacing(1),
    minWidth: 400,
  },
}));


const PremiumCalculator = (props) => {
  const [name, setName] = useState("");
  const [age, setAge] = useState(0);
  const [sumInsured, setSumInsured] = useState(0);
  const [premium, setPremium] = useState(0);
  const [occupation, setOccupation] = useState(0);
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const [dateValue, setDateValue] = useState(moment(Date.now()));
  const classes = useStyles();

  moment().format();


  const handleChange = (event) => {
    if (event != undefined) {
      if (event.target != null) {
        switch (event.target.name) {
          case 'name':
            setName(event.target.value);
            break;
          case 'sumInsured':
            setSumInsured(event.target.value);
            break;
          case 'dob':
            _calculateAge(event.target.value);
            setDateValue(event.target.value);
            break;
          case 'occupation':
            setOccupation(event.target.value);
            break;
        }
      }
      else {
        _calculateAge(event);
        setDateValue(event);
      }

      if (name !== "" && dateValue !== "" && Number(occupation > 0) && Number(sumInsured) > 0 && Number(age) > 0 && (event.target.value !== '' || event !== '')) {
        setButtonDisabled(false)
      } else {
        setButtonDisabled(true)
      }
    }
  }

  const reset = () => {
    setName('');
    setSumInsured(0);
    setDateValue(new Date().toLocaleDateString('en-US'))
    setAge(0);
    setOccupation(0);
    setButtonDisabled(false)
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    getMonthlyPremium();
  }


  async function getMonthlyPremium() {
   let premium = {
      'name': name,
      'age': age,
      'dob': dateValue,
      'occupationId': occupation,
      'deathSumInsured': sumInsured
    }
    const response = await fetch('https://localhost:44304/api/Premium',
      {
        method: 'POST',
        headers: {
          'Accept': 'application/json',
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(premium),
      });
    const result = await response.json();
    if (response.status == 200) {
      if (response.json() != undefined) {
        setPremium(result);
      }
      else {
        setPremium(0);
      }
    }
  }

  const _calculateAge = (inputDate) => {
    const calculatedAge = moment().diff(inputDate, 'years');
    setAge(calculatedAge);
  }

  return (
    <form id="mpForm" noValidate
      autoComplete="off"
      onSubmit={handleSubmit}>
      <Grid container spacing={3}>
        <Grid item xs={12}>
          <TextField
            name="name"
            required
            label="Name"
            variant="outlined"
            style={{ width: '85%' }}
            helperText="Please enter your Name"
            value={name}
            onChange={handleChange}
            className={classes.fields} />
        </Grid>
        <Grid item xs={12} sm={6}>
          <MuiPickersUtilsProvider utils={DateFnsUtils}>
            <KeyboardDatePicker
              variant="inline"
              autoOk="true"
              format="dd/MM/yyyy"
              margin="normal"
              id="date-picker-inline"
              name="dob"
              required
              label="DOB"
              value={dateValue}
              onChange={handleChange}
              helperText="Please enter your Date Of Birth, must be between 1901 to 2020"
              className={classes.fields}
              KeyboardButtonProps={{
                'aria-label': 'change date',
              }}
            />
          </MuiPickersUtilsProvider>
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField id="age"
            label="Age"
            variant="outlined"
            value={moment().diff(dateValue, 'years')}
            disabled
            type="number"
            helperText="Auto Calculated"
            onChange={handleChange}
            className={classes.fields} />
        </Grid>
        <Grid item xs={12} sm={6} >
          <FormControl
            variant="outlined"
            id="occupation"
            className={classes.fields}>
            <InputLabel id="demo-simple-select-autowidth-label">Occupation</InputLabel>
            <Select
              labelId="demo-simple-select-autowidth-label"
              required
              label="Occupation"
              name="occupation"
              value={occupation}
              onChange={_calculateAge, handleChange}>
              {props.occupations.map(ocpt =>
                <MenuItem key={ocpt.id} value={ocpt.id}>{ocpt.name}</MenuItem>)
              }
            </Select>
            <FormHelperText>Please select Occupation</FormHelperText>
          </FormControl>
        </Grid>
        <Grid item xs={12} sm={6}>
          <TextField
            name="sumInsured"
            required
            label="Death - Sum Insured"
            variant="outlined"
            type="number"
            value={sumInsured}
            onChange={handleChange}
            helperText="Please enter Sum Insured on Death"
            className={classes.fields} />
        </Grid>
        {premium > 0 ?
          <Grid item sm={12}>
            <TextField
              name="premium"
              required
              label="Monthly premium"
              variant="outlined"
              type="number"
              value={premium}
              helperText="Monthly Premium on Death for given Sum Insured"
              className={classes.fields} />
          </Grid>
          : <div></div>}
        <Grid item xs={12} sm={6}>
          <Button variant="contained"
            color="primary"
            type="submit" disabled={buttonDisabled} >
            Calculate
        </Button>
        </Grid>
        <Grid item xs={12} sm={6}>
          <Button variant="contained"
            color="secondary"
            type="submit" onClick={reset}>
            Reset
        </Button>
        </Grid>
      </Grid>

    </form>
  );
}

export default PremiumCalculator;