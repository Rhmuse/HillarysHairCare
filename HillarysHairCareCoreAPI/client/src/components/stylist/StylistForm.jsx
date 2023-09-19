import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { Button, Container, Form, FormGroup, Input, Label } from 'reactstrap';
import { addStylist } from '../../data/stylistData';

export const StylistForm = () => {
	const [stylistBuilder, setStylistBuilder] = useState({});

	const navigate = useNavigate();

	const handleSubmit = () => {
		addStylist(stylistBuilder).then(() => {
			navigate('/stylists');
		});
	};

	return (
		<>
			<Container style={{ margin: '1rem 0rem' }}>
				<h3>New Stylist</h3>
			</Container>
			<Container>
				<Form>
					<FormGroup>
						<Label htmlFor='stylist-firstName-input'>
							First Name
						</Label>
						<Input
							id='stylist-firstName-input'
							type='text'
							value={stylistBuilder.firstName}
							onChange={(e) => {
								const copy = { ...stylistBuilder };
								copy.firstName = e.target.value;
								setStylistBuilder(copy);
							}}
						/>
					</FormGroup>
					<FormGroup>
						<Label htmlFor='stylist-lastName-input'>
							Last Name
						</Label>
						<Input
							id='stylist-lastName-input'
							type='text'
							value={stylistBuilder.lastName}
							onChange={(e) => {
								const copy = { ...stylistBuilder };
								copy.lastName = e.target.value;
								setStylistBuilder(copy);
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
