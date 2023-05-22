import { useQuery } from 'react-query';
import { coreRestClient } from '../../../utilities/RestClients';
import { BRANCH_TYPE_ALL } from '../../../constants';

const getBranches = async branchType => {
  if (branchType === BRANCH_TYPE_ALL) {
    const response = await coreRestClient.get('/branch');
    return response.data;
  }

  const response = await coreRestClient.get(`/branch?branchType=${branchType}`);
  return response.data;
};

const useQueryBranches = (branchType = BRANCH_TYPE_ALL) => {
  const { status, data, refetch, error } = useQuery(
    [`branches-${branchType}`, branchType],
    () => getBranches(branchType),
    {
      enabled: !!branchType,
      refetchOnWindowFocus: false,
    }
  );

  return {
    status,
    data,
    refetch,
    error,
  };
};

export default useQueryBranches;
