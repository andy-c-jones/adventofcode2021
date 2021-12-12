import {executeDay, readFish} from "./day6";

describe("readFish", () => {
    it("should parse the give file and return a list of fish", () => {
        let expected = [
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 4},
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 1},
            {daysUntilNewFish: 2},
        ];
        let actual = readFish('day6/testInput.txt');
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});


describe("executeDay", () => {
    it("should decrease each of the fishes daysUntilNewFish", () => {

        let expected = [
            {daysUntilNewFish: 2},
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 2},
            {daysUntilNewFish: 0},
            {daysUntilNewFish: 1},
        ];

        let fishies = [
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 4},
            {daysUntilNewFish: 3},
            {daysUntilNewFish: 1},
            {daysUntilNewFish: 2},
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});