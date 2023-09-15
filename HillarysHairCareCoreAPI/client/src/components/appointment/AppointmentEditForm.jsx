import { Button, Form, FormGroup, Input, Label } from 'reactstrap';

export const AppointmentEditForm = ({
	appointment,
	loadAppointments,
	handleModal,
}) => {
	const handleSubmit = () => {};
	return (
		<>
			<h4>Edit Appointment</h4>
			<Form>
				<FormGroup>
					<Label htmlFor='stylist-select'>Stylist</Label>
					<Input type='select'>
						<option value={0}>Select a stylist...</option>
					</Input>
				</FormGroup>
				<FormGroup>
					<Label>Services</Label>
					<Input />
				</FormGroup>
				<FormGroup>
					<Label>Date</Label>
					<Input />
				</FormGroup>
				<FormGroup>
					<Label>Time</Label>
					<Input />
				</FormGroup>
				<Button type='submit' onClick={() => handleSubmit()}>
					Submit
				</Button>
			</Form>
		</>
	);
};
