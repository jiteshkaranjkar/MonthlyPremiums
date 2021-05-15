import React, { useState, useEffect } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import TextField from '@material-ui/core/TextField';

const useStyles = makeStyles((theme) => ({
  container: {
    display: 'flex',
    flexWrap: 'wrap',
    width: 400,
    marginLeft:10,
  },
}));


export default function DatePickers() {
  const [dateValue, setDateValue] = useState(new Date().toLocaleDateString('en-US'));
  const classes = useStyles();

  useEffect(() => {
    //setDateValue(/*dateValue('MM', Date().getMonth() + 1));*/

  })

  const handleDateChange = (event) => {
    console.log(event.target.value);
    setDateValue(event.target.value)
  }

  return (
    <TextField
      id="date"
      variant="outlined"
      label="DOB"
      value={dateValue}
      onChange={handleDateChange}
      type="date"
      className={classes.container}
      InputLabelProps={{
        shrink: true,
      }}
    />
  );
}