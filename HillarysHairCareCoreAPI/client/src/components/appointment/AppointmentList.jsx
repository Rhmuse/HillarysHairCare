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
					<th>Stylist</th>
					<th>Customer</th>
					<th>Services</th>
					<th>Date</th>
					<th>Time</th>
					<th>Total</th>
				</tr>
			</thead>
			<tbody>
				{appointments.map((a) => {
					const [date, time] = a.date.split('T');
					return (
						<tr key={`appointment-${a.id}`}>
							<th scope='row'>{a.id}</th>
							<td>{a.stylist.fullName}</td>
							<td>{a.customer.fullName}</td>
							<td>
								{a.appointmentServices.map((as) => {
									return as.service.name + ', ';
								})}
							</td>
							<td>{date}</td>
							<td>{time.slice(0, 5)}</td>
							<td>{a.total}</td>
						</tr>
					);
				})}
			</tbody>
		</Table>
	);
};
