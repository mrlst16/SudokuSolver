import axios from "axios";
import config from "../config.json"
import { SudokuAnalyticsResponse } from "../models/SudokuAnalyticsResponse";
import { ApiResponse } from "../models/ApiResponse";

export function callSolve(
    input: string
    ) : Promise<any>
    {
        const customConfig = {
            headers: {
                'Content-Type': 'application/json'
            }
        };
        return axios.post(
                    config.baseUrl + '/api/Solver/solve',
                    input,
                    customConfig
        );
    }