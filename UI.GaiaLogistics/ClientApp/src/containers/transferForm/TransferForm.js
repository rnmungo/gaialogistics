import { useEffect, useState } from 'react';
import MuiAddCircleIcon from '@mui/icons-material/AddCircle';
import MuiCloseIcon from '@mui/icons-material/Close';
import MuiBox from '@mui/material/Box';
import MuiList from '@mui/material/List';
import MuiListItem from '@mui/material/ListItem';
import MuiListItemText from '@mui/material/ListItemText';
import MuiIconButton from '@mui/material/IconButton';
import MuiLoadingButton from '@mui/lab/LoadingButton';
import MuiPaper from '@mui/material/Paper';
import MuiStack from '@mui/material/Stack';
import MuiTextField from '@mui/material/TextField';
import MuiTypography from '@mui/material/Typography';
import { UsersDropdownContainer } from '../usersDropdown';
import {
  DestinationBranchesDropdownContainer,
  OriginBranchesDropdownContainer,
} from '../branchDropdown';
import { ProductsAutocompleteContainer } from '../productsAutocomplete';
import { useSnackbar } from '../../contexts/snackbar';
import { useMutationTransferStock } from '../../hooks/useMutations';
import { DEFAULT_FORM_STATE, DEFAULT_PRODUCT_STATE } from './constants';

const TransferFormContainer = () => {
  const mutation = useMutationTransferStock();
  const snackbar = useSnackbar();
  const [formState, setFormState] = useState(DEFAULT_FORM_STATE);
  const [productState, setProductState] = useState(DEFAULT_PRODUCT_STATE);

  useEffect(() => {
    if (mutation.status === 'success') {
      snackbar.success('¡Bien! La transferencia se realizó con éxito');
      mutation.reset();
      setFormState(DEFAULT_FORM_STATE);
      setProductState(DEFAULT_PRODUCT_STATE);
    }

    if (mutation.status === 'error') {
      snackbar.error(
        mutation.error.response?.data?.message || mutation.error.message
      );
      mutation.reset();
    }
  }, [mutation, snackbar]);

  const handleChangeUser = value => {
    setFormState(prevState => ({ ...prevState, userId: value }));
  };

  const handleChangeDestinationBranch = value => {
    setFormState(prevState => ({ ...prevState, destinationId: value }));
  };

  const handleChangeOriginBranch = value => {
    setFormState(prevState => ({ ...prevState, originId: value }));
  };

  const handleChangeProduct = value => {
    setProductState(prevState => ({ ...prevState, id: value?.id || '', name: value?.label || '' }));
  };

  const handleChangeQuantity = event => {
    const { value } = event.target;
    setProductState(prevState => ({ ...prevState, quantity: Number(value) }));
  };

  const handleClickAddItem = () => {
    if (!productState.id) {
      snackbar.caution('Debe seleccionar un producto');
      return;
    }

    if (!productState.quantity) {
      snackbar.caution('Debe seleccionar la cantidad');
      return;
    }

    if (formState.items.some(item => item.id === productState.id)) {
      const newItems = [...formState.items];
      const index = newItems.findIndex(item => item.id === productState.id);
      newItems[index].quantity += productState.quantity;
      setFormState(prevState => ({ ...prevState, items: newItems }));
      setProductState(DEFAULT_PRODUCT_STATE);
    } else {
      setFormState(prevState => ({
        ...prevState,
        items: [...prevState.items, productState],
      }));
      setProductState(DEFAULT_PRODUCT_STATE);
    }
  };

  const handleClickSend = () => {
    if (!formState.originId) {
      snackbar.caution('Debe seleccionar el depósito de origen');
      return;
    }

    if (!formState.destinationId) {
      snackbar.caution('Debe seleccionar el destino');
      return;
    }

    if (!formState.userId) {
      snackbar.caution('Debe seleccionar el responsable');
      return;
    }

    if (formState.items.length === 0) {
      snackbar.caution('Debe seleccionar al menos un producto');
      return;
    }

    const params = {
      ...formState,
      items: formState.items.map(item => ({
        productId: item.id,
        quantity: item.quantity,
      }))
    };
    mutation.mutate(params);
  };

  return (
    <>
      <MuiPaper sx={{ width: '100%', p: 2 }}>
        <MuiTypography
          variant="body2"
          component="p"
          color="grey.600"
          sx={{ fontWeight: 500 }}
        >
          Datos de la transferencia
        </MuiTypography>
        <MuiStack sx={{ py: 3 }} direction="row" spacing={2} alignItems="start">
          <OriginBranchesDropdownContainer keyField="id" value={formState.originId} onChange={handleChangeOriginBranch} />
          <DestinationBranchesDropdownContainer keyField="id" value={formState.destinationId} onChange={handleChangeDestinationBranch} />
          <UsersDropdownContainer keyField="id" value={formState.userId} onChange={handleChangeUser} />
        </MuiStack>
        <MuiTypography
          variant="body2"
          component="p"
          color="grey.600"
          sx={{ fontWeight: 500 }}
        >
          Productos
        </MuiTypography>
        <MuiStack sx={{ py: 3 }} direction="row" spacing={2} alignItems="center">
          <ProductsAutocompleteContainer
            value={{ id: productState.id, label: productState.name }}
            onChange={handleChangeProduct}
          />
          <MuiTextField
            id="product-quantity"
            label="Cantidad"
            value={productState.quantity}
            variant="outlined"
            sx={{ width: 150 }}
            type="number"
            onChange={handleChangeQuantity}
          />
          <MuiIconButton
            color="secondary"
            size="large"
            aria-label="add to operation"
            onClick={handleClickAddItem}
          >
            <MuiAddCircleIcon />
          </MuiIconButton>
        </MuiStack>
        <MuiLoadingButton
          aria-label="Button to transfer"
          loading={mutation.status === 'loading'}
          loadingIndicator="Enviando"
          color="primary"
          variant="contained"
          type="submit"
          onClick={handleClickSend}
        >
          ENVIAR
        </MuiLoadingButton>
      </MuiPaper>
      {formState.items.length > 0 && (
        <MuiBox sx={{ width: '100%', p: 2 }}>
          <MuiList>
            {formState.items.map(item => (
              <MuiListItem
                key={item.id}
                secondaryAction={
                  <MuiIconButton
                    edge="end"
                    aria-label={`remove ${item.name}`}
                    onClick={() => {
                      const newItems = formState.items.filter(
                        i => i.id !== item.id
                      );
                      setFormState(prevState => ({
                        ...prevState,
                        items: newItems,
                      }));
                    }}
                  >
                    <MuiCloseIcon color="error" />
                  </MuiIconButton>
                }
              >
                <MuiListItemText primary={item.name} secondary={`${item.quantity} unidades`} />
              </MuiListItem>
            ))}
          </MuiList>
        </MuiBox>
      )}
    </>
  );
};

export default TransferFormContainer;
