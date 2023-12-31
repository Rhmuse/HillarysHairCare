const _apiUrl = "/customers"

export const getCustomers = () => {
    return fetch(_apiUrl).then(res => res.json());
}

export const addCustomer = (customer) => {
    return fetch(_apiUrl, {
        method: 'POST',
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(customer)
    });
}