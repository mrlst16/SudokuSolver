import axios from "axios";
import config from "../config.json"

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
                    config.baseUrl + '/api/Solver/solve',
                    input,
                    customConfig
        );
    }