package com.krm3d.question.application.features.impl;

import com.krm3d.question.application.features.QuestionCommandService;
import com.krm3d.question.application.features.dtos.CreatedQuestionDto;
import com.krm3d.question.application.features.dtos.DeletedQuestionDto;
import com.krm3d.question.application.features.dtos.UpdatedQuestionDto;
import com.krm3d.question.domain.entities.Question;
import com.krm3d.question.persistance.repositories.QuestionRepository;
import org.modelmapper.ModelMapper;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class QuestionCommandServiceImpl  implements QuestionCommandService {
    private QuestionRepository questionRepository;
    private ModelMapper modelMapper;
    @Autowired
    public QuestionCommandServiceImpl(QuestionRepository questionRepository, ModelMapper modelMapper) {
        this.questionRepository = questionRepository;
        this.modelMapper = modelMapper;
    }

    @Override
    public CreatedQuestionDto add(CreatedQuestionDto createdQuestionDto) {
        var mappedQuestion= this.modelMapper.map(createdQuestionDto, Question.class);
        this.questionRepository.save(mappedQuestion);
        return  createdQuestionDto;
    }

    @Override
    public DeletedQuestionDto delete(String id) {
       var getId = this.questionRepository.findById(id).get();
       this.questionRepository.delete(getId);
       var result = this.modelMapper.map(getId,DeletedQuestionDto.class);
       return  result;
    }

    @Override
    public UpdatedQuestionDto update(UpdatedQuestionDto updatedQuestionDto) {
       var mappedQuestion = this.modelMapper.map(updatedQuestionDto,Question.class);
       this.questionRepository.save(mappedQuestion);
       return updatedQuestionDto;
    }
}
