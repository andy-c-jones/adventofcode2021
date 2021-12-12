import {executeDay} from "./day";

describe("executeDay", () => {
    it("should decrease each of the fishes daysUntilNewFish", () => {

        let expected = [
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 2
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 3
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 0
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 1
            },
        ];

        let fishies = [
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 3
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 4
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 1
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 2
            },
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });

    it("should add new fish to the end of the list and reset to 6 when a fishes daysUntilNewFish is zero", () => {
        let expected = [
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 6
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 8
            }
        ];

        let fishies = [
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 0
            }
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });

    it("should add new fish to the end of the list and reset to 6 when a fishes daysUntilNewFish is zero", () => {
        let expected = [
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 6
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 0
            },
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 8
            },
        ];

        let fishies = [
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 0
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 1
            },
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });

    it("should deduplicate any fish groups with the same daysUntilNewFish", () => {
        let fishies = [
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 6
            },
            {
                amountOfFishRepresented: 1,
                daysUntilNewFish: 6
            },
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 8
            },
            {
                amountOfFishRepresented: 2,
                daysUntilNewFish: 8
            },
        ];

        let expected = [
            {
                amountOfFishRepresented: 3,
                daysUntilNewFish: 5
            },
            {
                amountOfFishRepresented: 4,
                daysUntilNewFish: 7
            },
        ];

        let actual = executeDay(fishies);
        expect(JSON.stringify(actual)).toBe(JSON.stringify(expected));
    });
});