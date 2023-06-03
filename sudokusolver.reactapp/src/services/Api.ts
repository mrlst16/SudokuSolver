import axios from "axios";

export async function callSolve(
    input: string,
    ) : Promise<any>
    {
        const customConfig = {
            headers: {
                'Content-Type': 'application/json'
            }
        };
        return await axios.post(
                    'https://localhost:7215/api/Solver/solve',
                    input,
                    customConfig
        );
    }