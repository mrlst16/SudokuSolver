import axios from "axios";
import { SudokuAnalysisResponse } from "../models/SudokuAnalyticsResponse";

function callSolve(
    input: string
    ) : SudokuAnalysisResponse
    {
        let response: SudokuAnalysisResponse = new SudokuAnalysisResponse();

        axios.post('https://localhost:7215/api/Solver/solve', input)
        .then(response => {
            console.log("response");
            console.log(response);
            response = response.data;
        })
        .catch(error => {
            console.error(error);
        });
        return response;
    }