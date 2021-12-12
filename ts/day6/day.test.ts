import {executeDay} from "./day";

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

    it("should add new fish to the end of the list and reset to 6 when a fishes daysUntilNewFish is zero", () => {
        let expected = [
            {daysUntilNewFish: 6},
            {daysUntilNewFish: 8}
        ];

        let fishies = [
            {daysUntilNewFish: 0}
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });

    it("should add new fish to the end of the list and reset to 6 when a fishes daysUntilNewFish is zero", () => {
        let expected = [
            {daysUntilNewFish: 6},
            {daysUntilNewFish: 0},
            {daysUntilNewFish: 6},
            {daysUntilNewFish: 8},
            {daysUntilNewFish: 8},
        ];

        let fishies = [
            {daysUntilNewFish: 0},
            {daysUntilNewFish: 1},
            {daysUntilNewFish: 0},
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});