import { useState } from 'react';
import { toast } from 'react-toastify';
import { CreateGame, DeleteGame, EditGame} from '../../../common/services/api/games/GamesApi';

export const useGameHandlers = () => {
  const [gameData, setGameData] = useState({//Allows to track the status of form data
    name: '',
    developer: '',
    description: '',
    price: '',
    releaseDate: '',
    gameGenre: '',
    image: null,
  });

  //Get the event (e) and updates the corresponding property in gameData
  const handleChange = (e) => {
    const { name, value } = e.target;
    setGameData((prevData) => ({ ...prevData, [name]: value }));
  };

  const handleImageChange = (e, setPreviewImage) => {
    const imageFile = e.target.files[0];
    console.log('imageFile:', imageFile);
    setGameData((prevGameData) => ({
      ...prevGameData,
      image: imageFile,
    }));
    setPreviewImage(URL.createObjectURL(imageFile));
  };

  const handleCreate = async (e) => {
    e.preventDefault();
    try {
      const formData = new FormData();
      formData.append('name', gameData.name);
      formData.append('developer', gameData.developer);
      formData.append('description', gameData.description);
      formData.append('price', gameData.price);
      formData.append('releaseDate', gameData.releaseDate);
      formData.append('gameGenre', gameData.gameGenre);
      formData.append('imageFile', gameData.image);
      
      const response = await CreateGame(formData);
      console.log('Game created successfully:', response);

      toast.success('Game created successfully', {// Show successful notification
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    } catch (error) {
      console.error('Error creating game:', error);
      toast.error('Error creating game. Please try again.', {// Show error notification
      position: 'top-right',
      autoClose: 3000,
      hideProgressBar: false,
      closeOnClick: true,
      pauseOnHover: true,
      draggable: true,
    });
  }
};

  const handleEditChange = (e, field) => {
    const { value } = e.target;
    console.log(`Setting ${field} to:`, value);
    setGameData((prevData) => ({
      ...prevData,
      [field]: value,
    }));
  };

  const handleEdit = async (id) => {
    try {
      console.log('gameData before Form:', gameData);
      console.log('Image before Form:', gameData.image);
      if (!gameData.image) {
        console.error('Image is null');
        return;
      }
      const formData = new FormData();
      formData.append('name', gameData.name);
      formData.append('developer', gameData.developer);
      formData.append('description', gameData.description);
      formData.append('price', gameData.price);
      formData.append('releaseDate', gameData.releaseDate);
      formData.append('gameGenre', gameData.gameGenre);
      formData.append('imageFile', gameData.image);
  
      console.log('Form after:', formData);

      const response = await EditGame(id, formData);
      console.log('Game updated successfully:', response);
  
      toast.success('Game edited successfully', {
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    } catch (error) {
      console.error('Error updating game:', error);
      toast.error('Error editing game. Please try again.', {
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    }
};

  const handleDelete = async (id) => {
    try {
      const response = await DeleteGame(id);
      console.log('Game deleted successfully:', response);
      
      toast.success('Game deleted successfully', {// Show successful notification
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    } catch (error) {
      console.error('Error deleting game:', error);
      toast.error('Error deleting game. Please try again.', {// Show error notification
        position: 'top-right',
        autoClose: 3000,
        hideProgressBar: false,
        closeOnClick: true,
        pauseOnHover: true,
        draggable: true,
      });
    }
  };

  return { gameData, handleChange, handleCreate, handleEditChange, handleEdit, handleDelete, handleImageChange};
};
