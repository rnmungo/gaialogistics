import { useState } from 'react';
import { func, object, string } from 'prop-types';
import MuiTextField from '@mui/material/TextField';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { DesktopDatePicker } from '@mui/x-date-pickers/DesktopDatePicker';
import { AdapterDateFns } from '@mui/x-date-pickers/AdapterDateFns';
import { esES } from '@mui/x-date-pickers';
import { es } from 'date-fns/locale';

const DatePicker = ({
  className = '',
  label,
  value = new Date(),
  onChange = () => { },
  ...datePickerProps
}) => {
  const [valueState, setValueState] = useState(value);

  const handleChange = newValue => {
    setValueState(newValue);
    const { name, id } = datePickerProps;
    onChange({ target: { id, name, value: newValue } });
  };

  return (
    <LocalizationProvider
      dateAdapter={AdapterDateFns}
      adapterLocale={es}
      localeText={
        esES.components.MuiLocalizationProvider.defaultProps.localeText
      }
    >
      <DesktopDatePicker
        className={className}
        label={label}
        inputFormat="dd/MM/yyyy"
        value={valueState}
        onChange={handleChange}
        renderInput={params => <MuiTextField {...params} />}
        {...datePickerProps}
      />
    </LocalizationProvider>
  );
};

DatePicker.propTypes = {
  className: string,
  label: string.isRequired,
  value: object,
  onChange: func,
};

export default DatePicker;
