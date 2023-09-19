import { useEffect, useState } from 'react';
import { Button, Container, Table } from 'reactstrap';
import { getStylists, toggleStylistActivity } from '../../data/stylistData';
import { Link } from 'react-router-dom';

export const StylistList = () => {
	const [stylists, setStylists] = useState([]);

	useEffect(() => {
		loadStylists();
	}, []);

	const loadStylists = () => {
		getStylists().then(setStylists);
	};

	const handleStylistActivityToggle = (id) => {
		toggleStylistActivity(id).then(() => {
			loadStylists();
		});
	};

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
				<h3>Stylists</h3>
				<Link to='/stylists/create'>
					<Button>Add Stylist</Button>
				</Link>
			</Container>
			<Table>
				<thead>
					<tr>
						<th>Id</th>
						<th>Name</th>
						<th>Active</th>
						<th></th>
					</tr>
				</thead>
				<tbody>
					{stylists.map((s) => (
						<tr key={`stylist-${s.id}`}>
							<th scope='row'>{s.id}</th>
							<td>{s.fullName}</td>
							<td>{s.isActive ? '🟢' : '🔴'}</td>
							<td>
								<Button
									onClick={(e) => {
										handleStylistActivityToggle(s.id);
									}}>
									{s.isActive ? 'Deactivate' : 'Activate'}
								</Button>
							</td>
						</tr>
					))}
				</tbody>
			</Table>
		</>
	);
};
