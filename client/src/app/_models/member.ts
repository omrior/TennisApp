import { Photo } from "./photo";

export interface Member {
    id: number;
    username: string;
    photoUrl: string;
    gender: string;
    age: number;
    firstName: string;
    lastName: string;
    created: Date;
    lastActive: Date;
    leagueLevel: string;
    points: number;
    city: string;
    experience: string;
    photos: Photo[];
}


