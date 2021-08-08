import { Photo } from "./Photo";

export interface Member {
    id: number;
    userName: string;
    photoUrl: string;
    gender: string;
    age: number;
    firstName: string;
    lastName: string;
    created: Date;
    lastActive: Date;
    level: number;
    points: number;
    city: string;
    photos: Photo[];
}


