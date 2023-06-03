import axios from "axios";
import { SudokuAnalysisResponse } from "../models/SudokuAnalyticsResponse";

export async function callSolve(
    input: string,
    ) : Promise<any>
    {
        let response: SudokuAnalysisResponse = new SudokuAnalysisResponse();
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
                    // )
        // .then(response => {
        //     console.log("response");
        //     console.log(response);
        //     response = response.data.data;
        // })
        // .catch(error => {
        //     console.error(error);
        // });

        // return response;
    }