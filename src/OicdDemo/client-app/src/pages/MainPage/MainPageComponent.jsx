import React, { useState, useEffect } from 'react';
import './MainPageComponent.scss';
import { useSelector, useDispatch } from 'react-redux';
import FileComponent from '../../components/FileComponent/FileComponent';
import { createFileFromApi } from '../../services/file-service';
import { getFiles, fetchFilesDataThunk } from '../../redux-resource/file-reducer';
import  axios from 'axios';

const MainPageComponent = (props) => {
       const fileList = useSelector(getFiles);
       const [newFile, setNewFile] = useState('');
       const dispatch = useDispatch();

       const clickNewFile = () => {
              var file = {
                     friendlyName:newFile
              };
              createFileFromApi(file).then(()=> {
                     dispatch(fetchFilesDataThunk());
              });
	};

       const logout = () => {
              axios(`${process.env.REACT_APP_BACKEND_BASE_URL}Auth/Logout`)
              .then((response: AxiosResponse) => {
                     window.location.reload();
              });
	};


       useEffect(() => {
              dispatch(fetchFilesDataThunk());
            }, [dispatch]);

       return (
              <div class="wrapper">
                     <div class="content">
                     <div class="title">File manager</div>
                     <button onClick={logout}>Logout</button>
			<input type="text" value={newFile} onChange={e => setNewFile(e.target.value)}></input>
			<button onClick={clickNewFile}>Add file</button>
                     <br/>
                     {fileList.payload.files.data.map((file, i) => <FileComponent file={file} key={i} />)}
                     </div>
              </div>
       );
     }
export default MainPageComponent;