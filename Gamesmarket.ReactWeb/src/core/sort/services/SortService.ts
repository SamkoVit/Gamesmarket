import $api from "../../../http";
import { AxiosResponse } from "axios";
import { IGame } from "../models/IGame";

export default class SortService {
  static getGamesByIdDesc(): Promise<AxiosResponse<IGame[]>> {
    return $api.get<IGame[]>("/games/sort/by-id-desc");
  }
  static getGamesByReleaseDate(
    ascending: boolean,
  ): Promise<AxiosResponse<IGame[]>> {
    return $api.get<IGame[]>(`/games/sort/by-release-date/${ascending}`);
  }
  static getGamesByPrice(ascending: boolean): Promise<AxiosResponse<IGame[]>> {
    return $api.get<IGame[]>(`/games/sort/by-price/${ascending}`);
  }
}
