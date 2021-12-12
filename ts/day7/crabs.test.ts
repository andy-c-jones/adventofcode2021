import {calculatePartOne, calculatePartTwo} from "./crabs";

describe("calculatePartOne", () => {

    let cases = [
        {numbers: [16, 1, 2, 0, 4, 2, 7, 1, 2, 14], expected: 37},
        {numbers: [10, 12, 12, 23, 33, 34, 321, 453, 453, 675], expected: 1846},
    ];

    for (const input of cases) {
        it("should return the sum or the distances from current positions to the median position", () => {
            let actual = calculatePartOne(input.numbers);
            expect(actual).toBe(input.expected);
        });
    }
});


describe("calculatePartTwo", () => {

    let cases = [
        {numbers: [16, 1, 2, 0, 4, 2, 7, 1, 2, 14], expected: 168},
        {numbers: [10, 12, 12, 23, 33, 34, 321, 453, 453, 675], expected: 281982},
    ];

    for (const input of cases) {
        it("should return cost to move to the cheapest position", () => {
            let actual = calculatePartTwo(input.numbers);
            expect(actual).toBe(input.expected);
        });
    }
});



