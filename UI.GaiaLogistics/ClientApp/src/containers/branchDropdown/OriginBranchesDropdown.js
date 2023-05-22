import { func, oneOf, string } from 'prop-types';
import get from 'lodash.get';
import { BRANCH_TYPE_DEPOSIT } from '../../constants';
import { Dropdown } from '../../components/dropdown';
import { useQueryBranches } from '../../hooks/useQueries';

const OriginBranchesDropdownContainer = ({ keyField = 'id', value = '', onChange = () => { } }) => {
  const { data, status, error } = useQueryBranches(BRANCH_TYPE_DEPOSIT);

  return (
    <Dropdown
      sx={{ width: 240 }}
      label="Origen"
      ariaLabel="origin-branch"
      helperText={status === 'error' && (error.response?.data?.message || error.message)}
      value={value}
      items={data ? data.map(branch => ({ id: get(branch, keyField, ''), text: branch.name })) : []}
      onChange={onChange}
    />
  );
};

OriginBranchesDropdownContainer.propTypes = {
  value: string,
  onChange: func,
  keyField: oneOf(['code', 'id']),
};

export default OriginBranchesDropdownContainer;
