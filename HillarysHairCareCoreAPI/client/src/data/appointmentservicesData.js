const _apiUrl = "/appointmentservices"

export const getAppointmentServicesById = (id) => {
    return fetch(`${_apiUrl}/${id}`).then(res => res.json());
}

export const updateAppoitmentServices = (appointmentId, appointmentServices) => {
    return fetch(`${_apiUrl}/${appointmentId}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(appointmentServices)
    })
};

export const addAppointmentServices = (appointmentServices) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(appointmentServices)
    })
}