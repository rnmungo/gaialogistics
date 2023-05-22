import { func, oneOf, string } from 'prop-types';
import get from 'lodash.get';
import { Dropdown } from '../../components/dropdown';
import { useQueryUsers } from '../../hooks/useQueries';

const UsersDropdownContainer = ({ keyField = 'id', value, onChange = () => { } }) => {
  const { data, status, error } = useQueryUsers();

  return (
    <Dropdown
      sx={{ width: 240 }}
      label="Responsable"
      ariaLabel="owner-user"
      helperText={status === 'error' && (error.response?.data?.message || error.message)}
      value={value}
      items={data ? data.map(user => ({ id: get(user, keyField, ''), text: `${user.name} ${user.lastName}` })) : []}
      onChange={onChange}
    />
  );
};

UsersDropdownContainer.propTypes = {
  value: string,
  onChange: func,
  keyField: oneOf(['email', 'id']),
};

export default UsersDropdownContainer;
