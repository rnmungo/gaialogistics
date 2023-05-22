import { func, oneOf, string } from 'prop-types';
import get from 'lodash.get';
import { BRANCH_TYPE_ALL } from '../../constants';
import { Dropdown } from '../../components/dropdown';
import { useQueryBranches } from '../../hooks/useQueries';

const DestinationBranchesDropdownContainer = ({ keyField = 'id', value = '', onChange = () => { } }) => {
  const { data, status, error } = useQueryBranches(BRANCH_TYPE_ALL);

  return (
    <Dropdown
      sx={{ width: 240 }}
      label="Destino"
      ariaLabel="destination-branch"
      helperText={status === 'error' && (error.response?.data?.message || error.message)}
      value={value}
      items={data ? data.map(branch => ({ id: get(branch, keyField, ''), text: branch.name })) : []}
      onChange={onChange}
    />
  );
};

DestinationBranchesDropdownContainer.propTypes = {
  value: string,
  onChange: func,
  keyField: oneOf(['code', 'id']),
};

export default DestinationBranchesDropdownContainer;
