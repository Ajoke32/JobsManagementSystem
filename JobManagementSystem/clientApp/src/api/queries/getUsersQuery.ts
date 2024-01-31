import { errorFields } from "../fragments/errorFields";


export const getUsersQuery = `
query GetUsers{
    users{
        all{
            errors{
                ...errorFields
            },
            isSuccess,
            data{
                id,
                email
            }
        }
    }
}

${errorFields}
`