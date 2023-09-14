const _apiUrl = "/stylists"

export const getStylists = () => {
    return fetch(_apiUrl).then(res => res.json());
}