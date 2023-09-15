const _apiUrl = "/customers"

export const getCustomers = () => {
    return fetch(_apiUrl).then(res => res.json());
}