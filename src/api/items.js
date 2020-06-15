const get = async (uri) => {
    return await fetch(uri, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
}

export async function getItems() {
    return await get(`localhost/items`)
}
