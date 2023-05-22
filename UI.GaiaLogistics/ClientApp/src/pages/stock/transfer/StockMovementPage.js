import MuiBox from '@mui/material/Box';
import MuiTypography from '@mui/material/Typography';
import { TransferFormContainer } from '../../../containers/transferForm';

const StockMovementPage = () => (
  <>
    <MuiTypography component="h1" variant="h4">Movimiento de Stock</MuiTypography>
    <MuiBox sx={{ py: 4 }}>
      <TransferFormContainer />
    </MuiBox>
  </>
);

export default StockMovementPage;
