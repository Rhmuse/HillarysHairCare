import { Nav, NavItem, NavLink, Navbar, NavbarBrand } from 'reactstrap';
import { Outlet } from 'react-router-dom';

function App() {
	return (
		<>
			<Navbar color='info' expand='md'>
				<Nav navbar>
					<NavbarBrand href='/'>💇 Hillary's Hair Care</NavbarBrand>
					<NavItem>
						<NavLink href='/stylists'>Stylists</NavLink>
					</NavItem>
					<NavItem>
						<NavLink href='/appointments'>Appointments</NavLink>
					</NavItem>
					<NavItem>
						<NavLink href='/customers'>Customers</NavLink>
					</NavItem>
				</Nav>
			</Navbar>
			<Outlet />
		</>
	);
}

export default App;
