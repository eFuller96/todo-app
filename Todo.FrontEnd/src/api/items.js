import config from '../config.js'

const get = async (uri) => {
    return await fetch(uri, {
        method: 'GET',
        headers: {
            'Access-Control-Allow-Origin': '*'
        }
    })
}

const post = (uri, payload) => {
    return fetch(uri, {
        method: 'POST',
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(payload)
    })
}

const baseUrl = "https://localhost:5001"

export async function getItems() {
    return await get(`${baseUrl}/item`)
}

export function saveItem(payload) {
    return post(`${baseUrl}/item`, payload)
}
