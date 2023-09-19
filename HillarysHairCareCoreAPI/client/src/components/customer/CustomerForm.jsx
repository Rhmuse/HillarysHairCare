import { useState } from 'react';
import { Button, Container, Form, FormGroup, Input, Label } from 'reactstrap';
import { addCustomer } from '../../data/customerData';
import { useNavigate } from 'react-router-dom';

export const CustomerForm = () => {
	const [customerBuilder, setCustomerBuilder] = useState({});

	const navigate = useNavigate();

	const handleSubmit = () => {
		addCustomer(customerBuilder).then(() => {
			navigate('/customers');
		});
	};

	return (
		<>
			<Container style={{ margin: '1rem 0rem' }}>
				<h3>New Customer</h3>
			</Container>
			<Container>
				<Form>
					<FormGroup>
						<Label htmlFor='customer-firstName-input'>
							First Name
						</Label>
						<Input
							id='customer-firstName-input'
							type='text'
							value={customerBuilder.firstName}
							onChange={(e) => {
								const copy = { ...customerBuilder };
								copy.firstName = e.target.value;
								setCustomerBuilder(copy);
							}}
						/>
					</FormGroup>
					<FormGroup>
						<Label htmlFor='customer-lastName-input'>
							Last Name
						</Label>
						<Input
							id='customer-lastName-input'
							type='text'
							value={customerBuilder.lastName}
							onChange={(e) => {
								const copy = { ...customerBuilder };
								copy.lastName = e.target.value;
								setCustomerBuilder(copy);
							}}
						/>
					</FormGroup>
					<Button
						onClick={() => {
							handleSubmit();
						}}>
						Submit
					</Button>
				</Form>
			</Container>
		</>
	);
};
