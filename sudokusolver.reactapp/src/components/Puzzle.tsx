import "../styles/Puzzle.css"
import { FC } from "react";

interface PuzzleProps{
    Grid : number[][],
    FontSize?: number
}

const Puzzle : FC<PuzzleProps> = ({Grid, FontSize}) => {

    if(FontSize == null)
        FontSize = 25

    return(
        <>
            <table
                className="puzzle"
                style={{fontSize:FontSize}}
                >
                    { 
                        Grid.map((x)=>
                        <tr>
                            {x.map(v=> <td>{v}</td>)}
                        </tr>
                        )
                    }
            </table>    
        </>
    )
}

export default Puzzle