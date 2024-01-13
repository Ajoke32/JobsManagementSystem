

export const getUsersQuery = `
query GetUsers{
    users{
        all{
            id,
            email
        }
    }
}
`