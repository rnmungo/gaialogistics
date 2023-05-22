import LocalShippingIcon from '@mui/icons-material/LocalShipping';
import AssessmentIcon from '@mui/icons-material/Assessment';

export const ROUTES = [
  {
    name: 'Movimientos de Stock',
    path: '/',
    Icon: LocalShippingIcon,
  },
  {
    name: 'Reporte de Operaciones',
    path: '/report',
    Icon: AssessmentIcon,
  },
  {
    name: 'Reporte Diario',
    path: '/daily-report',
    Icon: AssessmentIcon,
  }
];
