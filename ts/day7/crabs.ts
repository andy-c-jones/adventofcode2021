import {median} from "./math";

export function calculate(input: number[]) {
    let number = Math.floor(median(input));
    return input.map(n => Math.abs(n - number))
        .reduce((p, c) => p + c);
}