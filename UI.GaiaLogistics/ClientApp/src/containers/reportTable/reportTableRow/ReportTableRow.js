import { useState } from 'react';
import { arrayOf, number, shape, string } from 'prop-types';
import get from 'lodash.get';
import MuiBox from '@mui/material/Box';
import MuiCollapse from '@mui/material/Collapse';
import MuiIconButton from '@mui/material/IconButton';
import MuiPaper from '@mui/material/Paper';
import MuiStack from '@mui/material/Stack';
import MuiTable from '@mui/material/Table';
import MuiTableBody from '@mui/material/TableBody';
import MuiTableCell from '@mui/material/TableCell';
import MuiTableHead from '@mui/material/TableHead';
import MuiTableRow from '@mui/material/TableRow';
import MuiTypography from '@mui/material/Typography';
import MuiKeyboardArrowDownIcon from '@mui/icons-material/KeyboardArrowDown';
import MuiKeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import useDateFormatter from '../../../hooks/useDateFormatter';

const ReportTableRow = ({ row }) => {
  const [open, setOpen] = useState(false);
  const { getDateTimeLocalString } = useDateFormatter();

  return (
    <>
      <MuiTableRow sx={{ '& > *': { borderBottom: 'unset' } }}>
        <MuiTableCell>
          <MuiIconButton
            aria-label="expand row"
            size="small"
            onClick={() => setOpen(prevState => !prevState)}
          >
            {open ? <MuiKeyboardArrowUpIcon /> : <MuiKeyboardArrowDownIcon />}
          </MuiIconButton>
        </MuiTableCell>
        <MuiTableCell component="th" scope="row" align="left">
          <MuiStack direction="column">
            <MuiTypography component="span" variant="body1">
              {get(row, 'branchOrigin.name', '-')}
            </MuiTypography>
            <MuiTypography component="span" variant="body2" color="grey">
              {get(row, 'branchOrigin.code', '-')}
            </MuiTypography>
          </MuiStack>
        </MuiTableCell>
        <MuiTableCell align="left">
          <MuiStack direction="column">
            <MuiTypography component="span" variant="body1">
              {get(row, 'branchDestination.name', '-')}
            </MuiTypography>
            <MuiTypography component="span" variant="body2" color="grey">
              {get(row, 'branchDestination.code', '-')}
            </MuiTypography>
          </MuiStack>
        </MuiTableCell>
        <MuiTableCell align="left">
          <MuiStack direction="column">
            <MuiTypography component="span" variant="body1">
              {`${get(row, 'user.name', '-')} ${get(row, 'user.lastName', '-')}`}
            </MuiTypography>
            <MuiTypography component="span" variant="body2" color="grey">
              {get(row, 'user.email', '-')}
            </MuiTypography>
          </MuiStack>
        </MuiTableCell>
        <MuiTableCell align="left">
          <MuiTypography component="span" variant="body1">
            {getDateTimeLocalString(new Date(row.createdAt))}
          </MuiTypography>
        </MuiTableCell>
      </MuiTableRow>
      <MuiTableRow>
        <MuiTableCell style={{ paddingBottom: 0, paddingTop: 0 }} colSpan={6}>
          <MuiCollapse in={open} timeout="auto" unmountOnExit>
            <MuiBox sx={{ my: 2, p: 2 }} component={MuiPaper}>
              <MuiTypography variant="h6" gutterBottom component="div">
                Detalle de productos
              </MuiTypography>
              <MuiTable size="small" aria-label="report">
                <MuiTableHead>
                  <MuiTableRow>
                    <MuiTableCell align="left">Producto</MuiTableCell>
                    <MuiTableCell align="right">Cantidad</MuiTableCell>
                    <MuiTableCell align="right">Precio (ARS)</MuiTableCell>
                    <MuiTableCell align="right">Total ($)</MuiTableCell>
                  </MuiTableRow>
                </MuiTableHead>
                <MuiTableBody>
                  {row.stockMovementItems.map(stockMovementRow => (
                    <MuiTableRow key={stockMovementRow.id}>
                      <MuiTableCell component="th" scope="row" align="left">
                        {get(stockMovementRow, 'product.name', '-')}
                      </MuiTableCell>
                      <MuiTableCell align="right">{`${get(stockMovementRow, 'quantity', '-')} Uni.`}</MuiTableCell>
                      <MuiTableCell align="right">{get(stockMovementRow, 'product.price', '-')}</MuiTableCell>
                      <MuiTableCell align="right">
                        {(stockMovementRow?.quantity && stockMovementRow?.product?.price)
                          ? stockMovementRow.quantity * stockMovementRow.product.price
                          : 0
                        }
                      </MuiTableCell>
                    </MuiTableRow>
                  ))}
                </MuiTableBody>
              </MuiTable>
            </MuiBox>
          </MuiCollapse>
        </MuiTableCell>
      </MuiTableRow>
    </>
  );
};

ReportTableRow.propTypes = {
  row: shape({
    createdAt: string,
    branchOrigin: shape({
      code: string,
      name: string,
    }),
    branchDestination: shape({
      code: string,
      name: string,
    }),
    user: shape({
      name: string,
      lastName: string,
      email: string,
    }),
    stockMovementItems: arrayOf(shape({
      id: string,
      quantity: number,
      product: shape({
        name: string,
        price: number,
      }),
    }))
  }),
};

export default ReportTableRow;
