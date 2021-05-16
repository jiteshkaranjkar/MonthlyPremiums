import React, { Component } from "react";
import { TextField, Button, Grid, FormControl, InputLabel, Select, MenuItem, FormHelperText } from "@material-ui/core";
import DateFnsUtils from '@date-io/date-fns';
import { MuiPickersUtilsProvider, KeyboardDatePicker } from "@material-ui/pickers";
import moment from 'moment';


export class PremiumCalculator extends Component {
  constructor(props) {
    super(props)
    this.state = {
      name: "",
      age: 0,
      sumInsured: 0,
      premium: 0,
      occupation: 0,
      dateValue: moment(Date.now()),
      Occupations: [],
      loading: true,
      nameErrorMsg: '',
      sumErrorMsg: '',
      dateErrorMsg: '',
      occupationErrorMsg: ''
    }
    this.handleChange = this.handleChange.bind(this);
    this.reset = this.reset.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
    this.getMonthlyPremium = this.getMonthlyPremium.bind(this);
    this.calculateAge = this.calculateAge.bind(this);
    moment().format();
  }

  handleChange(event) {
    if (event != undefined) {
      if (event.target != null) {
        switch (event.target.name) {
          case 'name':
            this.setState({
              name: event.target.value
            });
            if (event.target.value !== '')
              this.setState({
                nameErrorMsg: ''
              });
            break;
          case 'sumInsured':
            this.setState({
              sumInsured: event.target.value
            });
            if (Number(event.target.value) > 0) {
              this.setState({
                sumErrorMsg: ''
              });
            }
            break;
          case 'dob':
            this.calculateAge(event.target.value);
            this.setState({
              dateValue: event.target.value
            });
            break;
          case 'occupation':
            this.setState({
              occupation: event.target.value
            });
            if (Number(event.target.value) > 0) {
              this.setState({
                occupationErrorMsg: ''
              });
            }
            break;
        }
      }
      else {
        this.calculateAge(event);
        this.setState({
          dateValue: event
        });
      }

      if (this.state.name !== "" && this.state.dateValue !== "" && Number(this.state.occupation > 0) && Number(this.state.sumInsured) > 0 && Number(this.state.age) > 0 && (event.target.value !== '' || event !== '')) {
        this.setState({
          buttonDisabled: false
        });
      } else {
        this.setState({
          buttonDisabled: true
        });
      }
    }
  }

  reset(event) {
    event.preventDefault();
    this.setState({
      name: '',
      sumInsured: 0,
      dateValue: new Date().toLocaleDateString('en-US'),
      age: 0,
      occupation: 0,
      buttonDisabled: true,
      nameErrorMsg: '',
      sumErrorMsg: '',
      dateErrorMsg: '',
      occupationErrorMsg: '',
      premium: 0
    });
  }

  handleSubmit(event) {
    event.preventDefault();
    this.setState({
      occupation: event.target.value
    });
    if (Number(event.target.value) > 0) {
      this.setState({
        occupationErrorMsg: ''
      });
    }

    if (this.state.name !== "" && this.state.dateValue !== "" && Number(event.target.value > 0) && Number(this.state.sumInsured) > 0 && Number(this.state.age) > 0) {
      this.getMonthlyPremium(event.target.value);
    } else {
      if (this.state.name === "") {
        this.setState({
          nameErrorMsg: 'Please enter name to calculate monthly premium.'
        });
      }
      if (moment().diff(this.state.dateValue, 'years') <= 0) {
        this.setState({
          dateErrorMsg: 'Date Of Birth must be between 1901 to 2020 to calculate monthly premium.'
        });
      }
      if (Number(event.target.value) <= 0) {
        this.setState({
          occupationErrorMsg: 'Please select an occupation to calculate monthly premium'
        });
      }
      if (Number(this.state.sumInsured) <= 0) {
        this.setState({
          sumErrorMsg: 'Please enter Death - Sum Insured to calculate premium.'
        });
      }
    }
  }


  async getMonthlyPremium(ocptValue) {
    let premium = {
      'name': this.state.name,
      'age': this.state.age,
      'dob': this.state.dateValue,
      'occupationId': ocptValue,
      'deathSumInsured': this.state.sumInsured
    }
    const response = await fetch('https://monthlypremiumcalculator.azurewebsites.net/api/Premium',
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
      if (result != undefined) {
        this.setState({
          premium: result
        });
      }
      else {
        this.setState({
          premium: 0,
          occupationErrorMsg: 'Error occured while calculating Monthly premium, please try again.'
        });
      }
    }
  }

  calculateAge(inputDate) {
    const calculatedAge = moment().diff(inputDate, 'years');
    this.setState({
      age: calculatedAge
    });
    if (calculatedAge > 0) {
      this.setState({
        dateErrorMsg: ''
      });
    }
  }

  render() {
    return (
      <form id="mpForm" noValidate
        autoComplete="off">
        <Grid container spacing={3}>
          <Grid item xs={12}
            style={{ marginBottom: '20px' }}>
            <TextField
              name="name"
              required
              label="Name"
              variant="outlined"
              style={{ width: '83%' }}
              helperText="Please enter your Name"
              value={this.state.name}
              onChange={this.handleChange} />
            <FormControl>
              {this.state.nameErrorMsg !== ''
                ? <FormHelperText error id="component-error-text">Error : {this.state.nameErrorMsg}</FormHelperText>
                : <div></div>}
            </FormControl>
          </Grid>
          <Grid item xs={12} sm={6}
            style={{ width: '65%', marginBottom: '20px' }}>
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
                value={this.state.dateValue}
                onChange={this.handleChange}
                helperText="Please enter your Date Of Birth, must be between 1901 to 2020"
                KeyboardButtonProps={{
                  'aria-label': 'change date',
                }}
              />
            </MuiPickersUtilsProvider>
            <FormControl>
              {this.state.dateErrorMsg !== ''
                ? <FormHelperText error id="component-error-text">Error : {this.state.dateErrorMsg}</FormHelperText>
                : <div></div>}
            </FormControl>
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField id="age"
              label="Age"
              variant="outlined"
              value={moment().diff(this.state.dateValue, 'years')}
              disabled
              type="number"
              helperText="Auto Calculated"
              style={{ width: '65%', marginBottom: '20px' }}
              onChange={this.handleChange} />
          </Grid>
          <Grid item xs={12} sm={6}>
            <TextField
              name="sumInsured"
              required
              label="Death - Sum Insured"
              variant="outlined"
              type="number"
              style={{ width: '65%', marginBottom: '20px' }}
              value={this.state.sumInsured}
              onChange={this.handleChange}
              helperText="Please enter Sum Insured on Death" />
            <FormControl>
              {this.state.sumErrorMsg !== ''
                ? <FormHelperText error id="component-error-text">Error : {this.state.sumErrorMsg}</FormHelperText>
                : <div></div>}
            </FormControl>
          </Grid>
          <Grid item xs={12} sm={6}>
            <FormControl
              variant="outlined"
              required
              id="occupation"
              style={{ width: '65%', marginBottom: '20px' }}
              className='textfield'>
              <InputLabel id="demo-simple-select-autowidth-label">Occupation</InputLabel>
              <Select
                labelId="demo-simple-select-autowidth-label"
                label="Occupation"
                name="occupation"
                value={this.state.occupation}
                onChange={this.handleSubmit}>
                <MenuItem value={this.state.occupation}>
                  <em>None</em>
                </MenuItem>
                {this.props.occupations.map(ocpt =>
                  <MenuItem key={ocpt.id} value={ocpt.id}>{ocpt.name}</MenuItem>)
                }
              </Select>
              <FormHelperText>Please select Occupation</FormHelperText>
              <FormControl>
                {this.state.occupationErrorMsg !== ''
                  ? <FormHelperText error id="component-error-text">Error : {this.state.occupationErrorMsg}</FormHelperText>
                  : <div></div>}
              </FormControl>
            </FormControl>
          </Grid>
          {this.state.premium > 0 ?
            <Grid item sm={12}>
              <TextField
                name="premium"
                style={{ width: '65%' }}
                required
                label="Monthly premium"
                variant="outlined"
                type="number"
                value={this.state.premium}
                InputProps={{
                  readOnly: true,
                }}
                helperText="Monthly Premium on Death for given Sum Insured"
                className='textfield' />
            </Grid>
            : <div></div>}
          <Grid item xs={12} sm={6}>
            <Button variant="contained"
              color="secondary"
              type="submit" onClick={this.reset}>
              Reset
        </Button>
          </Grid>
        </Grid>

      </form>
    );
  }
}