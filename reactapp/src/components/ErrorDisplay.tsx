import { FC } from "react";
import { ApiErrors } from "../models/ApiErrors";
import "../styles/ErrorDisplay.css"

interface ApiErrorsProps{
    Errors: ApiErrors;
}

const ErrorDisplay : FC<ApiErrorsProps> = ({Errors}) => {
    if(Errors==undefined || Errors.Errors.length == 0 )
    return(
        <></>
    )
    else
    return(
        <div className="errorDisplay">
            <ul>
            {
                Errors.Errors.map(error=> 
                    <li>
                        {error.Message}
                    </li>
                )
            }
            </ul>
        </div>
    )
}
export default ErrorDisplay;