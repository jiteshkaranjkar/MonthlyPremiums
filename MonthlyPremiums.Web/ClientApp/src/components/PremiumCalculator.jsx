import React, { useState, useEffect } from "react";
import { TextField, Button, FormHelperText, Grid, FormControl, InputLabel, Select, MenuItem } from "@material-ui/core";
import { makeStyles } from '@material-ui/core/styles';
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
  const [occupation, setOccupation] = useState("");
  const [buttonDisabled, setButtonDisabled] = useState(true);
  const [dateValue, setDateValue] = useState(moment(new Date()).format("DD/MM/YYYY"));
  const classes = useStyles();

  moment().format();

  const handleChange = (event) => {
    if (event != undefined) {
      switch (event.target.name) {
        case 'name':
          setName(event.target.value);
          break;
        case 'sumInsured':
          setSumInsured(event.target.value);
          break;
        case 'dob':
          _calculateAge();
          setDateValue(event.target.value)
          break;
        case 'occupation':
          setOccupation(event.target.value);
          break;
      }

      if (name !== "" && dateValue !== "" && occupation != "" && Number(sumInsured) > 0) {
        setButtonDisabled(!buttonDisabled)
      }
    }
  }

  const reset = () => {
    setName('');
    setSumInsured(0);
    setDateValue(new Date().toLocaleDateString('en-US'))
    setAge(0);
    setOccupation('');
    setButtonDisabled(false)
  }

  const handleSubmit = (event) => {
    event.preventDefault();

    let calculatorParameters = {
      name: name,
      age: age,
      dob: dateValue,
      occupation: occupation,
      deathSumInsured: sumInsured
    }
    getMonthlyPremium();
  }


  async function getMonthlyPremium() {
    props.occupations.calculatorParameters = {

      'name': name,
      'age': 234,
      'dob': dateValue,
      'occupation': occupation,
      'deathSumInsured': sumInsured
    }
    const response = await fetch('https://localhost:44304/api/Premium',
      {
        method: 'POST',
        headers: {
          'Accept': 'application/json, application/xml, text/plain, text/html, *.*',
          'Content-Type': 'application/json; charset=UTF-8'
        },
        body: JSON.stringify(props.occupations.calculatorParameters),
      });
    const result = await response.json();
    if (response.status == 200) {
      if (response.json() != undefined)
        setPremium(0);
    }
    else {

    }
  }

  const _calculateAge = () => { 
    const calculatedAge = moment().diff(dateValue, 'years');
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
            fullWidth
            helperText="Please enter your Name"
            value={name}
            onChange={handleChange}
            className={classes.fields} />
        </Grid>
        <Grid item sm={6}>
          <TextField
            name="dob"
            required
            variant="outlined"
            label="DOB"
            value={dateValue}
            onChange={handleChange}
            helperText="Please enter your Date Of Birth from 1901 to 2013"
            type="date"
            className={classes.fields}
            InputLabelProps={{
              shrink: true,
            }}
          />
        </Grid>
        <Grid item sm={6}>
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
        <Grid item sm={6} >
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
              {props.occupations.occupationList.map(ocpt =>
                <MenuItem key={ocpt.id} value={ocpt.name}>{ocpt.name}</MenuItem>)
              }
            </Select>
          </FormControl>
        </Grid>
        <Grid item sm={6}>
          <TextField
            name="sumInsured"
            required
            label="Death - Sum Insured"
            variant="outlined"
            type="number"
            value={sumInsured}
            onChange={handleChange}
            className={classes.fields} />
        </Grid>

        <Grid item sm={6}>
          <Button variant="contained"
            color="primary"
            type="submit" disabled={buttonDisabled} >
            Calculate
        </Button>
        </Grid>
        <Grid item sm={6}>
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