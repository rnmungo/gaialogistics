import { useEffect, useState } from 'react';
import MuiAutocomplete from '@mui/material/Autocomplete';
import MuiTextField from '@mui/material/TextField';
import { useQueryProducts } from '../../hooks/useQueries';

const ProductsAutocompleteContainer = ({ value = '', onChange = () => { } }) => {
  const [valueState, setValueState] = useState(value);
  const { data, status, error } = useQueryProducts();

  useEffect(() => {
    setValueState(value);
  }, [value]);

  return (
    <MuiAutocomplete
      id="products"
      value={valueState}
      disablePortal
      disabled={['idle', 'loading', 'refetching', 'error'].includes(status)}
      options={data ? data.map(product => ({ id: product.id, label: product.name })) : []}
      sx={{ width: 300 }}
      onChange={(_, newValue) => {
        setValueState(newValue);
        onChange(newValue);
      }}
      renderInput={(params) => <MuiTextField {...params} label="Producto" helperText={status === 'error' && error.message} />}
    />
  );
};

export default ProductsAutocompleteContainer;
