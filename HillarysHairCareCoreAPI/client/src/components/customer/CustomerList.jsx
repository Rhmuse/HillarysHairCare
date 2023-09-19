import { useEffect, useState } from 'react';
import { Button, Container, Table } from 'reactstrap';
import { getCustomers } from '../../data/customerData';
import { Link } from 'react-router-dom';

export const CustomerList = () => {
	const [customers, setCustomers] = useState([]);

	const loadCustomers = () => {
		getCustomers().then(setCustomers);
	};

	useEffect(() => {
		loadCustomers();
	}, []);

	return (
		<>
			<Container
				style={{
					justifySelf: 'center',
					margin: '1rem',
					justifyContent: 'space-between',
					display: 'flex',
					padding: '1rem',
				}}>
				<h3>Customers</h3>
				<Link to='/customers/create'>
					<Button>Add Customer</Button>
				</Link>
			</Container>
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
		</>
	);
};
