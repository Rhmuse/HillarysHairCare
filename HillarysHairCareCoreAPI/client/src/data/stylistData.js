const _apiUrl = "/stylists"

export const getStylists = () => {
    return fetch(_apiUrl).then(res => res.json());
}

export const getActiveStylists = () => {
    return fetch(`${_apiUrl}/active`).then(res => res.json());
}

export const toggleStylistActivity = (id) => {
    return fetch(`${_apiUrl}/${id}/toggleActivity`, {
        method: "POST"
    });
}

export const addStylist = (stylist) => {
    return fetch(_apiUrl, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(stylist)
    })
}