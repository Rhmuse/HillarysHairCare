import { useEffect, useState } from 'react';
import { Button, Container, Modal, ModalBody, Table } from 'reactstrap';
import { cancelAppointment, getAppointments } from '../../data/appointmentData';
import { AppointmentEditForm } from './AppointmentEditForm';
import { Link } from 'react-router-dom';

export const AppointmentList = () => {
	const [appointments, setAppointments] = useState([]);
	const [selectedAppointment, setSelectedAppointment] = useState({});
	const [isModalOpen, setIsModalOpen] = useState(false);

	useEffect(() => {
		loadAppointments();
	}, []);

	const loadAppointments = () => {
		getAppointments().then(setAppointments);
	};

	const handleEdit = (appointment) => {
		setSelectedAppointment(appointment);
		handleModal();
	};

	const handleCancel = (appointment) => {
		cancelAppointment(appointment.id).then(() => {
			loadAppointments();
		});
	};

	const handleModal = () => {
		setIsModalOpen(!isModalOpen);
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
				<h3>Appointments</h3>
				<Link to='/appointments/create'>
					<Button>Schedule Appointment</Button>
				</Link>
			</Container>

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
						<th></th>
						<th></th>
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
								<td>
									<Button
										onClick={() => {
											handleEdit(a);
										}}>
										Edit
									</Button>
								</td>
								<td>
									<Button
										onClick={() => {
											handleCancel(a);
										}}>
										Cancel
									</Button>
								</td>
							</tr>
						);
					})}
				</tbody>
			</Table>
			<Modal isOpen={isModalOpen}>
				<ModalBody>
					<AppointmentEditForm
						appointment={selectedAppointment}
						loadAppointments={loadAppointments}
						handleModal={handleModal}
					/>
				</ModalBody>
			</Modal>
		</>
	);
};
