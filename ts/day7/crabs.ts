import {median} from "./math";

export function calculatePartOne(input: number[]) {
    let target = Math.floor(median(input));
    return input.map(n => Math.abs(n - target))
        .reduce((p, c) => p + c);
}

function getCostToReachTarget(distanceToTarget: number) {
    let counter = 0;
    for (let i = 1; i < distanceToTarget + 1; i++) {
        counter = counter + i
    }
    return counter;
}

function getCostToTarget(input: number[], target: number) {
    return input.map(n => Math.abs(n - target))
        .reduce((p, distanceToTarget) => p + getCostToReachTarget(distanceToTarget), 0);
}

export function calculatePartTwo(input: number[]) {
    let costs = Array.from(Array(Math.max(...input)).keys())
        .map(x => x + 1)
        .map(t => getCostToTarget(input, t));
    return Math.min(...costs);
}