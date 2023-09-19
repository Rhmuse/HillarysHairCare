import { useEffect, useState } from 'react';
import {
	Button,
	Col,
	Container,
	Form,
	FormGroup,
	Input,
	Label,
	Row,
} from 'reactstrap';
import { getActiveStylists } from '../../data/stylistData';
import { getServices } from '../../data/serviceData';
import { updateAppointment } from '../../data/appointmentData';
import { updateAppoitmentServices } from '../../data/appointmentservicesData';

// For Calculating Max Date
const oneYearFromToday = new Date();
oneYearFromToday.setFullYear(oneYearFromToday.getFullYear() + 1);

export const AppointmentEditForm = ({
	appointment,
	loadAppointments,
	handleModal,
}) => {
	const [appointmentBuilder, setAppointmentBuilder] = useState({});
	const [selectedServiceIds, setSelectedServiceIds] = useState([]);
	const [stylists, setStylists] = useState([]);
	const [services, setServices] = useState([]);

	useEffect(() => {
		getActiveStylists().then(setStylists);
		getServices().then(setServices);
		setAppointmentBuilder({
			stylistId: appointment.stylistId,
			id: appointment.id,
			date: appointment.date,
		});
		const serviceIds = [];
		appointment.appointmentServices.forEach((as) => {
			serviceIds.push(as.serviceId);
		});
		setSelectedServiceIds(serviceIds);
	}, []);

	const handleSubmit = () => {
		updateAppointment(appointmentBuilder)
			.then(() => {
				const appointmentServicesDTOArray = selectedServiceIds.map(
					(sId) => {
						return {
							appointmentId: appointmentBuilder.id,
							serviceId: sId,
						};
					}
				);
				updateAppoitmentServices(
					appointmentBuilder.id,
					appointmentServicesDTOArray
				);
			})
			.then(() => {
				loadAppointments();
			});
	};

	const handleCheckboxChange = (e) => {
		const copy = [...selectedServiceIds];
		const serviceId = parseInt(e.target.value);
		if (copy.includes(serviceId)) {
			const filteredServices = copy.filter((id) => id !== serviceId);
			setSelectedServiceIds(filteredServices);
		} else {
			copy.push(serviceId);
			setSelectedServiceIds(copy);
		}
	};

	const handleDateChange = (e) => {
		const time = appointmentBuilder.date.split('T')[1];
		const dateTime = e.target.value + 'T' + time;
		const copy = { ...appointmentBuilder };
		copy.date = dateTime;
		setAppointmentBuilder(copy);
	};

	const handleTimeChange = (e) => {
		let normalizedTime = e.target.value.split(':')[0] + ':00';
		if (parseInt(normalizedTime.split(':')[0]) < 10) {
			normalizedTime = '10' + normalizedTime.slice(2);
		} else if (parseInt(normalizedTime.split(':')[0]) > 18) {
			normalizedTime = '18' + normalizedTime.slice(2);
		}
		const date = appointmentBuilder.date.split('T')[0];
		const dateTime = date + 'T' + normalizedTime;

		const copy = { ...appointmentBuilder };
		copy.date = dateTime;
		setAppointmentBuilder(copy);
	};
	return (
		<>
			<Container
				style={{
					display: 'flex',
					flexDirection: 'row',
					justifyContent: 'space-between',
				}}>
				<h4>Edit Appointment</h4>
				<Button onClick={() => handleModal()}>X</Button>
			</Container>

			<Form>
				<FormGroup>
					<Label htmlFor='stylist-select'>Stylist</Label>
					<Input
						id='stylist-select'
						type='select'
						value={appointmentBuilder.stylistId}
						onChange={(e) => {
							const copy = { ...appointmentBuilder };
							copy.stylistId = e.target.value;
							setAppointmentBuilder(copy);
						}}>
						<option value={0}>Select a stylist...</option>
						{stylists.map((s) => {
							return (
								<option key={`stylist-${s.id}`} value={s.id}>
									{s.fullName}
								</option>
							);
						})}
					</Input>
				</FormGroup>
				<FormGroup>
					<Col>
						Services
						{services.map((s) => {
							return (
								<Row key={`service-checkbox-${s.id}`}>
									<Label htmlFor={`service-input-${s.id}`}>
										<Input
											checked={selectedServiceIds.includes(
												s.id
											)}
											id={`service-input-${s.id}`}
											type='checkbox'
											value={s.id}
											onChange={(e) => {
												handleCheckboxChange(e);
											}}
										/>{' '}
										{s.name}
									</Label>
								</Row>
							);
						})}
					</Col>
				</FormGroup>
				<FormGroup>
					<Label htmlFor='appointment-date-input'>Date</Label>
					<Input
						id='appointment-date-input'
						type='date'
						min={new Date().toLocaleDateString('en-CA')}
						max={oneYearFromToday.toLocaleDateString('en-CA')}
						value={appointmentBuilder?.date?.split('T')[0]}
						onChange={(e) => {
							handleDateChange(e);
						}}
					/>
				</FormGroup>
				<FormGroup>
					<Label htmlFor='appointment-time-input'>Time</Label>
					<Input
						id='appointment-time-input'
						type='time'
						min='10:00'
						max='18:00'
						value={appointmentBuilder?.date?.split('T')[1]}
						onChange={(e) => {
							handleTimeChange(e);
						}}
					/>
				</FormGroup>
				<Button type='submit' onClick={() => handleSubmit()}>
					Submit
				</Button>
			</Form>
		</>
	);
};
