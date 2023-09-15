import { useEffect, useState } from 'react';
import { Table } from 'reactstrap';
import { getCustomers } from '../../data/customerData';

export const CustomerList = () => {
	const [customers, setCustomers] = useState([]);

	const loadCustomers = () => {
		getCustomers().then(setCustomers);
	};

	useEffect(() => {
		loadCustomers();
	}, []);

	return (
		<Table>
			<thead>
				<tr>
					<th>Id</th>
					<th>Name</th>
				</tr>
			</thead>
			<tbody>
				{customers.map((c) => (
					<tr key={`customer-${c.id}`}>
						<th scope='row'>{c.id}</th>
						<td>{c.fullName}</td>
					</tr>
				))}
			</tbody>
		</Table>
	);
};
