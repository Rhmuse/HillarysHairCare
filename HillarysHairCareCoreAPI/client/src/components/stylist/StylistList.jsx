import { useEffect, useState } from 'react';
import { Button, Table } from 'reactstrap';
import { getStylists } from '../../data/stylistData';

export const StylistList = () => {
	const [stylists, setStylists] = useState([]);

	useEffect(() => {
		loadStylists();
	}, []);

	const loadStylists = () => {
		getStylists().then(setStylists);
	};

	return (
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
							<Button>Deactivate</Button>
						</td>
					</tr>
				))}
			</tbody>
		</Table>
	);
};
