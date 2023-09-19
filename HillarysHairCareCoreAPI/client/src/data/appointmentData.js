const _apiUrl = "/appointments"

export const getAppointments = () => {
    return fetch(_apiUrl).then(res => res.json());
}

export const cancelAppointment = (id) => {
    return fetch(`${_apiUrl}/${id}/cancel`, { method: "POST" })
}

export const updateAppointment = (appointment) => {
    return fetch(`${_apiUrl}/${appointment.id}`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(appointment)
    });
}

export const addAppointment = (appointment) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(appointment)
    }).then(res => res.json());
}