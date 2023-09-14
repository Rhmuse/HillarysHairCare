import { useEffect, useState } from 'react';
import { Table } from 'reactstrap';
import { getAppointments } from '../../data/appointmentData';

export const AppointmentList = () => {
	const [appointments, setAppointments] = useState([]);

	useEffect(() => {
		loadAppointments();
	}, []);

	const loadAppointments = () => {
		getAppointments().then(setAppointments);
	};

	return (
		<Table>
			<thead>
				<tr>
					<th>Id</th>
				</tr>
			</thead>
			<tbody>
				{appointments.map((a) => (
					<tr key={`appointment-${a.id}`}>
						<th scope='row'>{a.id}</th>
					</tr>
				))}
			</tbody>
		</Table>
	);
};
