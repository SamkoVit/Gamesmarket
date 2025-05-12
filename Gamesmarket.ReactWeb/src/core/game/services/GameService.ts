import $api from "../../../http";
import { AxiosResponse } from "axios";
import { IGame } from "../models/IGame";
import { GamesResponse } from "../models/response/GamesResponse";
import { DeleteGameResponse } from "../models/response/DeleteGameResponse";

export default class GameService {
  static getGames(): Promise<AxiosResponse<IGame[]>> {
    return $api.get<IGame[]>("/games");
  }

  static getGame(id: number): Promise<AxiosResponse<IGame>> {
    return $api.get<IGame>(`/games/${id}`);
  }

  static createGame(formData: FormData): Promise<AxiosResponse<GamesResponse>> {
    return $api.post<GamesResponse>("/games", formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  }

  static editGame(
    id: number,
    formData: FormData,
  ): Promise<AxiosResponse<GamesResponse>> {
    return $api.patch<GamesResponse>(`/games/${id}`, formData, {
      headers: {
        "Content-Type": "multipart/form-data",
      },
    });
  }

  static deleteGame(id: number): Promise<AxiosResponse<DeleteGameResponse>> {
    return $api.delete<DeleteGameResponse>(`/games/${id}`);
  }
}
